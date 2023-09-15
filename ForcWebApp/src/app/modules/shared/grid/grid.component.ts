import { Component } from '@angular/core';

@Component({
    selector: 'app-grid',
    templateUrl: 'grid.component.html',
    styleUrls: ['grid.component.css']
})
export class GridComponent {
    //Первый инпут - сервис получения данных с сервера.
    //Тут прописываю чсто работу с интерфейсом этого сервиса


    //Второй инпут сервис, определяющий набор колонок

    public data = [
        {
            name: 'Piter',
            age: 27,
            sex: 'male'
        },
        {
            name: 'Fiasta',
            age: 10,
            sex: 'female'
        },
        {
            name: 'Ploshka',
            age: 44,
            sex: 'female'
        }
    ];

    clickRow(){
        alert('row clicked');
    }
}