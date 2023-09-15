import { NgModule } from '@angular/core'
import { GridComponent } from './grid.component';
import { DxDataGridModule } from 'devextreme-angular';

@NgModule({
    imports:[
        DxDataGridModule
    ],
    declarations:[
        GridComponent
    ],
    exports: [
        GridComponent
    ],
    providers: [

    ]
})
export class GridModule {

}