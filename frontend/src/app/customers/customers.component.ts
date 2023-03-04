import { Component, Input, OnInit } from '@angular/core';
import { Customer } from '../_models/customer';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  @Input() customersFromAppComponent: any;

  constructor() { }

  ngOnInit(): void {
  }

}
