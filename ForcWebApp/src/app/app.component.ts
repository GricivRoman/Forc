import { Component } from '@angular/core';
import { faCarrot  } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  protected title = 'ForcWebApp';
  protected carrotIcon = faCarrot;
}
