import { CommonModule } from '@angular/common';
import { Component} from '@angular/core';
import { ActionsComponent } from '../../components/actions/actions.component';
import { FindFormComponent } from '../../components/find-form/find-form.component'
import { NavChipsComponent } from '../../components/nav-chips/nav-chips.component';
import { QuickAddFormComponent } from '../../components/quick-add-form/quick-add-form.component';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  standalone: true,
  imports: [CommonModule, ActionsComponent, NavChipsComponent, QuickAddFormComponent, FindFormComponent, RouterModule]
})
export class HomeComponent {
  currentYear: number = new Date().getFullYear();

  constructor(private router: Router) {
  }

  navigateToSummary() {
    this.router.navigate(['/summary']);
  }
}
