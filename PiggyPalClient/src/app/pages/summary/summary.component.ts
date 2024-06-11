import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ITransaction } from 'src/app/interfaces/transaction.interface';
import { TransactionService } from 'src/app/services/transaction.service';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css'],
  standalone: true,
  imports: [CommonModule, MatTableModule]
})
export class SummaryComponent implements OnInit {
  transactions: ITransaction[] = [];
  categories: { [key: string]: number } = {};
  displayedColumns = ['transactionDate', 'transactionCategory','transactionDescription', 'transactionAmount'];;

  constructor(private _transactionService: TransactionService) {}

  ngOnInit() {
    this._transactionService.getTransactions().subscribe((transactions: ITransaction[]) => {
      this.transactions = transactions;
    });
  }
}
