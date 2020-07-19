import { CategoryListDto } from '@shared/service-proxies/service-proxies';
import { CategoryDto, CategoryServiceProxy } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { Component, OnInit, Output, EventEmitter, Injector } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent extends AppComponentBase implements OnInit {

  category: CategoryDto = new CategoryDto();
  data: CategoryListDto;
  @Output() onSave = new EventEmitter<any>();
  constructor(injector: Injector,
    public bsModalRef: BsModalRef,
    private categoryService: CategoryServiceProxy) {
    super(injector);
  }

  ngOnInit(): void {
    this.category = Object.assign({}, this.data);
  }
  save() {
    this.categoryService.updateCategory(this.category)
      .pipe(finalize(() => {
        this.notify.success('Category Updated Successfully');

      })).subscribe(() => {
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
  close() {
    this.bsModalRef.hide();
  }
}
