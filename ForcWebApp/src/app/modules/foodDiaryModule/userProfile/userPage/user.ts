import { SelectItem } from 'src/app/modules/shared/selectItem';
import { BaseEntity } from '../../../shared/baseEntity';
import { Guid } from 'guid-typescript';

export class UserModel extends BaseEntity {

	/* Имя пользователя */
	name: string;

	/* Дата рождения */
	birthDate?: Date;

	/* Гендер */
	gender: string;

	/* Пол */
	sex: SelectItem;

	/* ID категории физической активности */
	physicalActivityId?: Guid;

	/* Категория физической активности - ключ + наименование */
	physicalActivity: SelectItem;

	/* Рост */
	peight: number;
}