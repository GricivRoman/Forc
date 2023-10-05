import { SelectItem } from 'src/app/modules/shared/models/selectItem';
import { Guid } from 'guid-typescript';
import { EntityWithImage } from 'src/app/modules/shared/models/entityWithImage';

export class UserModel extends EntityWithImage {

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