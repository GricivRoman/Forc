import { Component, Injectable, ViewChild } from '@angular/core';
import { GridComponent } from '../../shared/module-frontend/forc-grid/grid.component';
import { GridOptionsService } from '../../shared/module-frontend/forc-grid/grid-options.service';
import { Column } from 'devextreme/ui/data_grid';
import { GridSelectionModeStates } from '../../shared/module-frontend/forc-grid/gridElementsModeStates';
import { GridDataService } from '../../shared/module-frontend/forc-grid/grid-data.service';
import { Observable, of } from 'rxjs';
import { GridOptions } from '../../shared/module-frontend/forc-grid/grid-options.component';
import { Guid } from 'guid-typescript';
import { HumanModel } from './human.model';

@Component({
	selector: 'app-diary-menu',
	templateUrl: 'diaryMenu.component.html'
})
export class DiaryMenuComponent {
	constructor(public gridOptionService: DiaryMenuGridOptionService){
	}

	@ViewChild(GridComponent, {static: false}) grid: GridComponent<HumanModel>;

	rowDoubleClick = () => {
		const data = this.grid.getSelectedRowsData();
		console.log(data);
	};

	add() {
		this.grid.dataSource.push({
			id: Guid.createEmpty(),
			name: 'Vanua',
			age: 33,
			sex: 'male'
		});
	}

	edit() {
		const data = this.grid.getSelectedRowsData();
		data[0].name='UUUUU';
	}

	delete() {
		console.log(this.grid.getSelectedRowsKeys());
	}
}

@Injectable()
export class DiaryMenuGridOptionService implements GridOptionsService, GridDataService<HumanModel> {
	getColumns(): Column[]{
		return [
			{
				dataField: 'name',
				caption: 'Name',
				dataType: 'string'
			},
			{
				dataField: 'age',
				caption: 'Age',
				dataType: 'number'
			},
			{
				dataField: 'sex',
				caption: 'Keks',
				dataType: 'string'
			}];
	}

	getGridOptions(): GridOptions {
		const options = new GridOptions();
		options.columns = this.getColumns();
		options.selectionMode = GridSelectionModeStates.single;

		return options;
	}

	getGridData(): Observable<HumanModel[]> {
		const data: HumanModel[] = [
			{
				id: Guid.create(),
				name: 'Piter',
				age: 27,
				sex: 'male'
			},
			{
				id: Guid.create(),
				name: 'Fiasta',
				age: 33,
				sex: 'female'
			},
			{
				id: Guid.create(),
				name: 'Ploshka',
				age: 44,
				sex: 'female'
			}
		];
		return of(data);
	}
}