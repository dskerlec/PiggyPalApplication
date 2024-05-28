import { Component, Input } from '@angular/core';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-nav-chips',
  templateUrl: './nav-chips.component.html',
  styleUrls: ['./nav-chips.component.css'],
  standalone: true,
  imports: [MatCardModule],
})
export class NavChipsComponent {
  @Input() chipName = '';

}
