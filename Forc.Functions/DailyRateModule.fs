namespace Forc.Functions

module DailyRateModule = 
    let roundDouble x i =
        round(x * double i) / double i
    
    type Sex = 
        | Male = 1
        | Female = 2
    
    // Передается при обращении к функции calculateBasalMetabolicRate
    type CalculationUnit(sex: Sex, currentBodyWeight: double, targetBodyWeight: double, height: double, age: double, physicalActivityMultiplier: double, daysToRichTarget: double) =
        member x.Sex = sex
        member x.CurrentBodyWeight = currentBodyWeight
        member x.TargetBodyWeight = targetBodyWeight
        member x.Height = height
        member x.Age = age
        member x.PhysicalActivityMultiplier = physicalActivityMultiplier
        member x.DaysToRichTarget = daysToRichTarget
    
    // Тип ответа - полный набор показателей дневной нормы
    type DailyRate(caloriesRate: double, fatRate: double, carbohydrateRate: double, proteinRate: double) =
        member x.CarbohydrateRate = carbohydrateRate
        member x.CaloriesRate = caloriesRate
        member x.FatRate = fatRate
        member x.ProteinRate = proteinRate

    // Норма нутриентов на килограмм тела
    type NutritionNorm(proteinMultiplier: double, fatMultiplier: double) =
        member x.ProteinMultiplier = proteinMultiplier
        member x.FatMultiplier = fatMultiplier
    
    // Тип диеты - набор или сушка
    type DietType =
        | Bulking = 1
        | Drying = 2
    
    // Набор констант
    let CalloriesPerGrammFat = 9.3
    let CalloriesPerGrammProtein = 4.1
    let CalloriesPerCarbohydrate = 4.1

    // Основная функция расчета дневной нормы
    let calculateDailyRate (x: CalculationUnit) : DailyRate =

        // Тип диеты
        let dietType = 
            if(x.CurrentBodyWeight > x.TargetBodyWeight)
                then DietType.Drying
            else DietType.Bulking

        // При сушке сжигаем жир, при наборе набираем белок
        let weightDeltaMultipleir (x: DietType): double =
            match x with
            | DietType.Drying -> CalloriesPerGrammProtein
            | DietType.Bulking -> CalloriesPerGrammFat
            | _ -> 10.0

        // Расчитать норму каллорий
        let calculateCaloriesRate =
            let calculateDefaultMetabolicRate (x: CalculationUnit) : double = 
                9.99 * x.CurrentBodyWeight + 6.25 * x.Height - 4.92 * x.Age

            let addSexConst i = 
                match x with
                | male when male.Sex = Sex.Male -> i + 5.0
                | female when female.Sex = Sex.Female -> i + 161.0
                | _ -> i + 0.0

            let correctByPhysicalActivity i =
                i * x.PhysicalActivityMultiplier
            
            let addTargetColotiesDelta i =
                let countTargetColotiesDelta = 
                    (x.TargetBodyWeight - x.CurrentBodyWeight) * 1000.0 / x.DaysToRichTarget / weightDeltaMultipleir dietType

                i + countTargetColotiesDelta

            x
            |> calculateDefaultMetabolicRate
            |> addSexConst
            |> correctByPhysicalActivity
            |> addTargetColotiesDelta
            |> roundDouble <| 2
        
        let calculateBodyMassIndex (x: CalculationUnit) : double =
            let calculateNormalBodyMassIndex =
                match x with
                | male when male.Sex = Sex.Male -> 23.0
                | female when female.Sex = Sex.Female -> 20.0
                | _ -> 0

            let correctByDietType i: double = 
                let dietTypeMultiplier (x: DietType) = 
                    match x with
                    | DietType.Drying -> 0.95
                    | DietType.Bulking -> 1.05
                    | _ -> 1.0

                i * dietTypeMultiplier dietType

            let correctBySexAndAge i = 
                let multiplier = 
                    let sexMultiplier = 
                        match x with
                        | male when x.Sex = Sex.Male -> 0.008
                        | female when x.Sex = Sex.Female -> 0.012
                        | _ -> 0

                    match x with
                    | yang when x.Age < 25.0 -> 1.0
                    | female when x.Sex = Sex.Female -> 1.0 + (x.Age - 25.0) * sexMultiplier
                    | _ -> 1.0

                i * multiplier
            
            calculateNormalBodyMassIndex
            |> correctByDietType
            |> correctBySexAndAge

        let calculateBodyMassByIndex i =
            let normalMass = i * (x.Height / 100.0) ** 2.0

            if (normalMass > x.CurrentBodyWeight)
                then normalMass
            else x.CurrentBodyWeight
        
        let calculateNutritionNorm : NutritionNorm =
            match x with
            |maleBulking when x.Sex = Sex.Male && dietType = DietType.Bulking -> new NutritionNorm(1.75, 1.1)
            |maleDrying when x.Sex = Sex.Male && dietType = DietType.Drying -> new NutritionNorm(1.5, 1)
            |femaleBulking when x.Sex = Sex.Female && dietType = DietType.Bulking -> new NutritionNorm(1.5, 1.35)
            |femaleDrying when x.Sex = Sex.Female && dietType = DietType.Drying -> new NutritionNorm(1.35, 1.5)
            |_ -> new NutritionNorm(2, 2)
        

        let calculateProteinRate = 
            x
            |> calculateBodyMassIndex
            |> calculateBodyMassByIndex
            |> (fun i -> i * calculateNutritionNorm.ProteinMultiplier)
            |> roundDouble <| 2

        let calculateFatRate = 
            x
            |> calculateBodyMassIndex
            |> calculateBodyMassByIndex
            |> (fun i -> i * calculateNutritionNorm.FatMultiplier)
            |> roundDouble <| 2

        let calculateCarbohydratesRate =
            (calculateCaloriesRate - calculateProteinRate * CalloriesPerGrammProtein - calculateFatRate * CalloriesPerGrammFat) / CalloriesPerCarbohydrate
            |> roundDouble <| 2

        new DailyRate(calculateCaloriesRate, calculateFatRate, calculateCarbohydratesRate, calculateProteinRate)