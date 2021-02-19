import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/Product';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class ProductService {
  private baseUrl: string = environment.baseUrl + 'api/';

  constructor(private http: HttpClient) {}

  public addProduct(product: Product) {
    return this.http.post(this.baseUrl + 'products', product);
  }

  public updateProduct(id: number, product: Product) {
    return this.http.put(this.baseUrl + 'products/' + id, product);
  }

  public getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl + `products`);
  }

  public deleteProduct(id: number) {
    return this.http.delete(this.baseUrl + 'products/' + id);
  }

  public getProductById(id: number): Observable<Product> {
    return this.http.get<Product>(this.baseUrl + 'products/' + id);
  }

  public searchProductsWithCategory(searchedValue: string): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}products/search-product-with-category/${searchedValue}`);
  }
}
