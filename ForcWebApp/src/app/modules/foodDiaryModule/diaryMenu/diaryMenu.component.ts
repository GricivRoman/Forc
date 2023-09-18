import { Component, Injectable, ViewChild } from '@angular/core'
import { GridComponent } from '../../shared/grid/grid.component';
import { GridOptions, GridOptionsService } from '../../shared/grid/grid-options.service';
import { Column } from 'devextreme/ui/data_grid'
import { gridSelectionModeStates } from '../../shared/grid/gridElementsModeStates';
import { GridDataService } from '../../shared/grid/grid-data.service';
import { Observable, of } from 'rxjs';

@Component({
    selector: 'app-diary-menu',
    templateUrl: 'diaryMenu.component.html'
})
export class DiaryMenuComponent {
    constructor(public gridOptionService: DiaryMenuGridOptionService){
    }

    @ViewChild(GridComponent, {static: false}) grid: GridComponent;

    rowDoubleClick = () => {
        const data = this.grid.getSelectedRowsData();
    }

    buttonClicked() {
        console.log(this.grid.getSelectedRowsData());
        this.grid.dataSource.push({
            id: null,
            name: 'Vanua',
            age: 33,
            sex: 'male'
        });
    }
}

@Injectable()
export class DiaryMenuGridOptionService implements GridOptionsService, GridDataService {
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
        }]
    }

    getGridOptions(): GridOptions {
        const options = new GridOptions();
        options.columns = this.getColumns();
        options.selectionMode = gridSelectionModeStates.single;

        return options;
    }

    getGridData(): Observable<any[]> {
        const data = [
            {
                id: 1,
                name: 'Piter',
                age: 27,
                sex: 'male'
            },
            {
                id: 2,
                name: 'Fiasta',
                age: 10,
                sex: 'female'
            },
            {
                id: 3,
                name: 'Ploshka',
                age: 44,
                sex: 'female'
            }
        ];
        
        return of(data);
    }
}