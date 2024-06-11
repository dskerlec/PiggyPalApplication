import { Component, EventEmitter, Input, Output } from '@angular/core';
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
  @Output() chipClicked = new EventEmitter<void>();

  onChipClicked() {
    this.chipClicked.emit();
  }
}
