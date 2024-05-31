import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { TransactionFormComponent } from '../transaction-form/transaction-form.component';

@Component({
  selector: 'app-find-form',
  templateUrl: './find-form.component.html',
  styleUrls: ['./find-form.component.css'],
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, TransactionFormComponent]
})
export class FindFormComponent implements OnInit {
  searchForm!: FormGroup;

  constructor(private fb: FormBuilder) {
  }

  ngOnInit(): void {
    this.searchForm = this.fb.group({
      date: [''],
      amount: [''],
      description: [''],
      category: ['']
    });
  }

  onSearch(): void {
    console.log(this.searchForm.value);
    // Handle search logic here
  }
}
