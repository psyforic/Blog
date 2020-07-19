import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Component, OnInit, Injector } from '@angular/core';
import { CategoryListDto, CategoryServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CreateCategoryComponent } from './create-category/create-category.component';
import { EditCategoryComponent } from './edit-category/edit-category.component';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  animations: [appModuleAnimation()],
  styleUrls: ['./categories.component.css'],
  providers: [CategoryServiceProxy]
})
export class CategoriesComponent extends AppComponentBase implements OnInit {

  categories: CategoryListDto[] = [];
  constructor(
    injector: Injector,
    private categoryService: CategoryServiceProxy,
    private _modalService: BsModalService) {
    super(injector);
  }

  ngOnInit(): void {
    this.getAll();
  }
  getAll() {
    this.categoryService.getAll()
      .pipe(finalize(() => {

      })).subscribe((result) => {
        this.categories = result.items;
      });
  }
  createCategory(): void {
    let createCategory: BsModalRef;
    createCategory = this._modalService.show(
      CreateCategoryComponent,
      {
        class: 'modal-lg',
      }
    );
    createCategory.content.onSave.subscribe(() => {
      this.getAll();
    });
  }
  edit(category: CategoryListDto) {
    let editCategory: BsModalRef;
    editCategory = this._modalService.show(
      EditCategoryComponent,
      {
        class: 'modal-lg',
        initialState: {
          data: category,
        },
      }
    );
    editCategory.content.onSave.subscribe(() => {
      this.getAll();
    });
  }
  delete(cat: CategoryListDto) {
    abp.message.confirm(
      'You want to delete Category ' + cat.name + '?',
      undefined,
      (result: boolean) => {
        if (result) {
          this.categoryService.delete(cat.id)
            .pipe(finalize(() => {
              this.notify.error('Deleted Successfully');
              this.getAll();
            })).subscribe(() => { });
        }
      }
    );
  }
}
