import { BaseEntity } from '../../shared/models/baseEntity';

export class HumanModel extends BaseEntity{
	name?: string;
	age?: number;
	sex?: string;
}