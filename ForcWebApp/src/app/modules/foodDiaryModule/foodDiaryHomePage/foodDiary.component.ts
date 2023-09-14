import { Component } from '@angular/core';
import { LocalStorageService } from '../../shared/localStorage.service';

@Component({
    selector: 'app-food-diary',
    templateUrl: 'foodDiary.component.html'
})
export class FoodDiaryComponent {
    constructor(private localStorageService: LocalStorageService){

    }
    
    click(){
        console.log(this.localStorageService.authInfo.token);
    }
}