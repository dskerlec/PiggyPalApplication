import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ICategory } from 'src/app/interfaces/category.interface';
import { ITransaction } from 'src/app/interfaces/transaction.interface';
import { CategoryService } from 'src/app/services/category.service';
import { TransactionService } from 'src/app/services/transaction.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  categories$: Observable<ICategory[]>;
  transactions$: Observable<ITransaction[]>;

  constructor(_categoryService: CategoryService, _transactionService: TransactionService) {
    this.categories$= _categoryService.getCategories();
    this.transactions$ = _transactionService.getTransactions();
  }
}
