import { Component } from "@angular/core";

@Component({
    selector: 'app-select-single',
    templateUrl: 'select-single.component.html'
})
export class SelectSingleComponent {
    sexList: SelectItem[] = [
        {
            value: '1',
            viewValue: 'M'
        },
        {
            value: '2',
            viewValue: 'F'
        }
    ]
}


interface SelectItem {
    value: string;
    viewValue: string;
  }