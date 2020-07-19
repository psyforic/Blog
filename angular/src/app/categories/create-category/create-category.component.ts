import { CategoryServiceProxy } from './../../../shared/service-proxies/service-proxies';
import { Component, OnInit, Injector, Output, EventEmitter } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { CategoryCreateInput } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-create-category',
  templateUrl: './create-category.component.html',
  styleUrls: ['./create-category.component.css']
})
export class CreateCategoryComponent extends AppComponentBase implements OnInit {

  category: CategoryCreateInput = new CategoryCreateInput();
  @Output() onSave = new EventEmitter<any>();
  constructor(injector: Injector,
    public bsModalRef: BsModalRef,
    private categoryService: CategoryServiceProxy) {
    super(injector);
  }

  ngOnInit(): void {
  }
  save() {
    this.categoryService.create(this.category)
      .pipe(finalize(() => {
        this.notify.success('Category Created Successfully');

      })).subscribe(() => {
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
  close() {
    this.bsModalRef.hide();
  }
}
