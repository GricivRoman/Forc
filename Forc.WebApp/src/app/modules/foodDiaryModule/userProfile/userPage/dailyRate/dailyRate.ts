import { Guid } from 'guid-typescript';
import { BaseEntity } from 'src/app/modules/shared/models/baseEntity';

/* Дневная норма потребления соответствующая цели */
export class DailyRate extends BaseEntity {

	/* Id цели */
	userTargetId: Guid;

	/* Норма потребления каллорий */
	caloriesRate: number;

	/* Норма потребления углеводов */
	carbohydrateRate: number;

	/* Норма потребления жиров */
	fatRate: number;

	/* Норма потребления белков */
	proteinRate: number;
}