import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ICategory } from 'src/app/interfaces/category.interface';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  categories$: Observable<ICategory[]>;

  constructor(_categoryService: CategoryService) {
    this.categories$= _categoryService.getCategories();
  }
}
