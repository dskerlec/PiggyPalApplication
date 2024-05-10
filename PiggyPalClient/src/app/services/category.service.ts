import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICategory } from '../interfaces/category.interface';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private apiUrl = 'http://localhost:5024/api/categories'; // TODO: pull this out to somewhere else so its just api/categories

  constructor(private _http: HttpClient) { }

  getCategories(): Observable<ICategory[]> {
    return this._http.get<ICategory[]>(this.apiUrl);
  }
}
