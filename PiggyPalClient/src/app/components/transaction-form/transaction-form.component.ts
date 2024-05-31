import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Observable } from 'rxjs';
import { ICategory } from '../../interfaces/category.interface';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-transaction-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './transaction-form.component.html',
  styleUrls: ['./transaction-form.component.css']
})
export class TransactionFormComponent implements OnInit {
  @Input() formGroup!: FormGroup;
  
  categories$: Observable<ICategory[]> = new Observable();

  categories: ICategory[] = [];

  constructor(private fb: FormBuilder, private _categoryService: CategoryService) { }

  ngOnInit(): void {
    this.categories$ = this._categoryService.getCategories();
    this.categories$.subscribe((categoriesFromDB) => {
      this.categories = categoriesFromDB;
    });
  }
}
