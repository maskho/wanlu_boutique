import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Customer } from './_models/customer';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Wanlu Boutique';
  customers: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('https://localhost:5005/api/customers').subscribe({
      next: res => this.customers = res,
      error: error => console.log(error),
      complete: () => console.log('request completed')
    })
  }

  searchResultMode(result: Customer) {
    this.customers = result;
  }

}
