import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { SearchService } from '../_services/search.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  @Output() searchResult = new EventEmitter();
  model: any = {}

  constructor(private searchService: SearchService) { }

  ngOnInit(): void {
  }

  search() {
    this.searchService.search(this.model).subscribe({
      next: response => {
        console.log(response);
        this.searchResult.emit(response);
      }, error: error => console.log(error)
    })
  }

}
