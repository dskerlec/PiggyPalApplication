import { Component, Input } from '@angular/core';
import {MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-actions',
  templateUrl: './actions.component.html',
  styleUrls: ['./actions.component.css'],
  standalone: true,
  imports: [MatCardModule,]
})
export class ActionsComponent {
  @Input() actionName = '';
  @Input() iconName = '';

}
