import { ProductService } from './../../services/product.service';
import { Product } from '../../shared/models/product';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-main-catalog',
  templateUrl: './main-catalog.component.html',
  styleUrls: ['./main-catalog.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class MainCatalogComponent implements OnInit {
  products: Product[];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.productService.getProducts()
    .subscribe(
      result => {
        this.products = result.items;
      });
  }

}
