import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { Customer } from '../_models/customer';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  baseUrl = 'https://localhost:5005/api/';

  constructor(private http: HttpClient) { }

  search(model: any) {
    return this.http.get<Customer>(this.baseUrl + 'customers/' + model.keyword).pipe(
      map((response: Customer) => {
        if (response != null) {
          localStorage.setItem('customer', JSON.stringify(response))
        }
        return [response];
      })
    );
  }
}
