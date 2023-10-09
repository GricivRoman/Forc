import { Guid } from 'guid-typescript';
import { BaseEntity } from 'src/app/modules/shared/models/baseEntity';
import { DailyRate } from '../dailyRate/dailyRate';

/* Цель пользователя */
export class UserTarget extends BaseEntity {
	/* ID пользователя */
	userId: Guid;

	/* Актуальность */
	relevance: boolean;

	/* Дата начала */
	dateStart: Date;

	/* Дата окончания */
	dateFinish: Date;

	/* Текущий вес тела */
	currentBodyWeight: number;

	/* Целевой вес тела */
	targetBodyWeight: number;

	/* ID дневной нормы в соответствии с актуальной целью */
	dailyRateId?: Guid;

	/* Дневная норма в соответствии с актуальной целью */
	dailyRate?: DailyRate;
}