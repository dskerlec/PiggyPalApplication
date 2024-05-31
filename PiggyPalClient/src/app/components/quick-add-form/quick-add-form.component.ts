import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ICategory } from '../../interfaces/category.interface';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { TransactionFormComponent } from '../transaction-form/transaction-form.component';

@Component({
  selector: 'app-quick-add-form',
  templateUrl: './quick-add-form.component.html',
  styleUrls: ['./quick-add-form.component.css'],
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, TransactionFormComponent],
})
export class QuickAddFormComponent implements OnInit {
  categories$: Observable<ICategory[]> = new Observable();
  
  categories: ICategory[] = [];
  transactionForm!: FormGroup;

  constructor(private fb: FormBuilder,) { }


  ngOnInit(): void {
    this.buildTransactionForm();
  }

  buildTransactionForm() {
    this.transactionForm = this.fb.group({
      date: ['', Validators.required],
      amount: ['', [Validators.required, Validators.pattern('^[0-9]+(\\.[0-9]{1,2})?$')]],
      description: ['', Validators.required],
      category: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.transactionForm.valid) {
      console.log(this.transactionForm.value);
      // TODO: add verification to user and reset the form, dont let them double submit, etc
    }
  }

}
