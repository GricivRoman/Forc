import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import { gridSelectionModeStates } from './gridElementsModeStates';
import { GridOptionsService } from './grid-options.service';
import { Column } from 'devextreme/ui/data_grid'
import { GridDataService } from './grid-data.service';


@Component({
    selector: 'app-grid',
    templateUrl: 'grid.component.html',
    styleUrls: ['grid.component.css']
})
export class GridComponent implements OnInit{
    @ViewChild(DxDataGridComponent, {static: false} ) grid: DxDataGridComponent;

    @Input()
    public optionsService: GridOptionsService;
    @Input()
    public dataService: GridDataService;

    @Input()
    public onRowDoubleCkick: Function;

    public dataSource: any[];
    protected gridWidth: string;
    protected selectionMode: string;
    protected columns: Column[];    

    protected allowColumnResizing: boolean;
    protected columnMinWidth: number;
    protected columnAutoWidth: boolean;
    protected pageSize: number;

    protected allowGrouping: boolean;
    protected expandAll: boolean = true;

    ngOnInit() {
        const options = this.optionsService.getGridOptions();
        this.columns = options.columns;
        this.loadData();

        this.selectionMode = options.selectionMode ?? gridSelectionModeStates.multiple;
        this.gridWidth = options.gridWidth ?? '100%';
        this.pageSize = options.pageSize ?? 20;

        this.allowColumnResizing = options.allowColumnResizing ?? true;
        this.columnMinWidth = options.columnMinWidth ?? 50;
        this.columnAutoWidth = options.columnAutoWidth ?? true;       

        this.allowGrouping = options.allowGrouping ?? false;
    }
    
    public getSelectedRowsData() : any[]{
        return this.grid.instance.getSelectedRowsData();
    }

    public getSelectedRowsKeys(): any[] {
        return this.grid.instance.getSelectedRowKeys();
    }

    public toggleGrouping(){
        if(this.allowGrouping = true){
            this.expandAll = !this.expandAll;
        }
    }

    public async refresh() {
        await this.loadData();
        this.grid.filterValue = null;
    }

    private async loadData(){
        await this.dataService.getGridData().subscribe((data) => {
            this.dataSource = data;
        });
    }
}