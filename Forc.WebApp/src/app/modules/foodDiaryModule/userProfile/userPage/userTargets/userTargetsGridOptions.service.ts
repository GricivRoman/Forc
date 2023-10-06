import { Injectable } from '@angular/core';
import { Column } from 'devextreme/ui/data_grid';
import { GridOptions } from 'src/app/modules/shared/module-frontend/forc-grid/grid-options.component';
import { GridOptionsService } from 'src/app/modules/shared/module-frontend/forc-grid/grid-options.service';
import { GridSelectionModeStates } from 'src/app/modules/shared/module-frontend/forc-grid/gridElementsModeStates';

@Injectable()
export class UserTargetGridOptionsService implements GridOptionsService {

	getColumns(): Column[]{
		return [
			{
				dataField: 'dateStart',
				caption: 'Date start',
				dataType: 'date'
			},
			{
				dataField: 'dateFinish',
				caption: 'Date finish',
				dataType: 'date'
			},
			{
				dataField: 'targetBodyWeight',
				caption: 'Target weight',
				dataType: 'number'
			},
			{
				dataField: 'relevance',
				caption: 'Relevance',
				dataType: 'boolean'
			}];
	}

	getGridOptions(): GridOptions {
		const options = new GridOptions();
		options.columns = this.getColumns();
		options.selectionMode = GridSelectionModeStates.single;
		return options;
	}
}