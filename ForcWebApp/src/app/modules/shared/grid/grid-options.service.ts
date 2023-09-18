import { Column } from 'devextreme/ui/data_grid'

export class GridOptions {
    columns: Column[];
    selectionMode?: string;
    gridWidth?: string;
    allowColumnResizing?: true;
    columnMinWidth?: number;
    columnAutoWidth?: boolean;
    pageSize?: number;
    allowGrouping?: boolean;
}

export interface GridOptionsService {
    getColumns(): Column[];
    getGridOptions(): GridOptions;
}