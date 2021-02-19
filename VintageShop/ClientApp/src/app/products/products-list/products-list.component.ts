import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from 'src/app/services/product.service';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationDialogService } from 'src/app/services/confirmation-dialog.service';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-product-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductListComponent implements OnInit {
  public products: any;
  public listComplet: any;
  //public searchTerm: string;
  public searchValueChanged: Subject<string> = new Subject<string>();


  constructor(private router: Router,
    private service: ProductService,
    private toastr: ToastrService,
    private confirmationDialogService: ConfirmationDialogService) { }


  ngOnInit() {
    this.getValues();
    /*
    this.searchValueChanged.pipe(debounceTime(1000))
      .subscribe(() => {
        this.search();
      });*/
  }

  private getValues() {

    this.service.getProducts().subscribe(products => {
      this.products = products;
      this.listComplet = products;
    });
  }

  public addProduct() {
    this.router.navigate(['/product']);
  }

  public editProduct(productId: number) {
    this.router.navigate(['/product/' + productId]);
  }

  public deleteProduct(productId: number) {
    this.confirmationDialogService.confirm('Atention', 'Do you really want to delete this product?')
      .then(() =>
        this.service.deleteProduct(productId).subscribe(() => {
          this.toastr.success('The product has been deleted');
          this.getValues();
        },
          err => {
            this.toastr.error('Failed to delete the product.');
          }))
      .catch(() => '');
  }

  public searchProducts() {
    this.searchValueChanged.next();
  }
  /*
  private search() {
    if (this.searchTerm !== '') {
      this.service.searchProductsWithCategory(this.searchTerm).subscribe(product => {
        this.products = product;
      }, error => {
        this.products = [];
      });
    } else {
      this.service.getProducts().subscribe(products => this.products = products);
    }
  }*/
}
