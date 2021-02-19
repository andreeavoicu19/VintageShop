import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Product } from 'src/app/models/Product';
import { ProductService } from 'src/app/services/product.service';
import { ToastrService } from 'ngx-toastr';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-product',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductComponent implements OnInit {
  public formData?: Product;
  public categories: any;

  constructor(public service: ProductService,
    private categoryService: CategoryService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
    let id;
    this.route.params.subscribe(params => {
      id = params['id'];
    });

    if (id != null) {
      this.service.getProductById(id).subscribe(product => {
        this.formData = product;
        const productDate = new Date(product.productDate);
        this.formData.productDate = { year: productDate.getFullYear(), month: productDate.getMonth(), day: productDate.getDay() };
      }, err => {
        this.toastr.error('An error occurred on get the record.');
      });
    } else {
      this.resetForm();
    }

    this.categoryService.getCategories().subscribe(categories => {
      this.categories = categories;
    }, err => {
      this.toastr.error('An error occurred on get the records.');
    });
  }

  public onSubmit(form: NgForm) {
    form.value.categoryId = Number(form.value.categoryId);
    form.value.productDate = this.convertStringToDate(form.value.productDate);
    if (form.value.id === 0) {
      this.insertRecord(form);
    } else {
      this.updateRecord(form);
    }
  }

  public insertRecord(form: NgForm) {
    this.service.addProduct(form.form.value).subscribe(() => {
      this.toastr.success('Registration successful');
      this.resetForm(form);
      this.router.navigate(['/products']);
    }, () => {
      this.toastr.error('An error occurred on insert the record.');
    });
  }

  public updateRecord(form: NgForm) {
    this.service.updateProduct(form.form.value.id, form.form.value).subscribe(() => {
      this.toastr.success('Updated successful');
      this.resetForm(form);
      this.router.navigate(['/products']);
    }, () => {
      this.toastr.error('An error occurred on update the record.');
    });
  }

  public cancel() {
    this.router.navigate(['/products']);
  }

  private resetForm(form?: NgForm) {
    if (form != null) {
      form.form.reset();
    }

    this.formData = {
      id: 0,
      name: '',
      description: '',
      value: 0,
      productDate: null,
      categoryId: 0
    };
  }

  private convertStringToDate(date: { year: any; month: any; day: any }){
    return new Date(`${date.year}-${date.month}-${date.day}`);
  }
}
