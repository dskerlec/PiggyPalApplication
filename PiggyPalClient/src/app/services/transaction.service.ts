import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ITransaction } from '../interfaces/transaction.interface';
import { Observable, map } from 'rxjs';
import { getCategoryName } from '../utils/category-utils';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  private apiUrl = `${environment.apiUrl}api/transaction`;

  constructor(private _http: HttpClient) { }

  getTransactions(): Observable<ITransaction[]> {
    return this._http.get<ITransaction[]>(`${this.apiUrl}/`).pipe(
      map((transactions: ITransaction[]) => // translate category ID to category name
        transactions.map((transaction) => ({
          ...transaction,
          categoryName: getCategoryName(transaction.categoryId)
        }))
      )
    );
  }

  getTransaction(id: number): Observable<ITransaction> {
    return this._http.get<ITransaction>(`${this.apiUrl}/${id}`);
  }

  createTransaction(transaction: ITransaction): Observable<ITransaction> {
    return this._http.post<ITransaction>(this.apiUrl, transaction);
  }

  updateTransaction(transaction: ITransaction): Observable<void> {
    return this._http.put<void>(`${this.apiUrl}/${transaction.transactionId}`, transaction);
  }

  deleteTransaction(id: number): Observable<void> {
    return this._http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
