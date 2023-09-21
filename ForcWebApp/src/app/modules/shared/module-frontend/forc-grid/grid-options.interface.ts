import { Column } from 'devextreme/ui/data_grid';
import { GridOptions } from './grid-options.component';

export interface GridOptionsInterface {
    getColumns(): Column[];
    getGridOptions(): GridOptions;
}