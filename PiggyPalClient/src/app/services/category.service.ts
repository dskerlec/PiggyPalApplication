import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICategory } from '../interfaces/category.interface';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private apiUrl = `${environment.apiUrl}api/categories`;

  constructor(private _http: HttpClient) { }

  getCategories(): Observable<ICategory[]> {
    return this._http.get<ICategory[]>(this.apiUrl);
  }
  getTransaction(id: number): Observable<ICategory> {
    return this._http.get<ICategory>(`${this.apiUrl}/${id}`);
  }

  createTransaction(category: ICategory): Observable<ICategory> {
    return this._http.post<ICategory>(this.apiUrl, category);
  }

  updateTransaction(category: ICategory): Observable<void> {
    return this._http.put<void>(`${this.apiUrl}/${category.categoryId}`, category);
  }

  deleteTransaction(id: number): Observable<void> {
    return this._http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
