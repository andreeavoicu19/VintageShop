export class Product {
  id: number;
  name: string;
  description: string;
  value: number;
  productDate: any;
  categoryId: number;
  constructor() {
    this.id = 0;
    this.name = '';
    this.description = '';
    this.value = 0;
    this.categoryId = 0;
  }
}
