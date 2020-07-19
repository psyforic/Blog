import { CategoriesComponent } from './../../categories/categories.component';
import {
  PostCreateInput,
  PostServiceProxy,
  CategoryListDto,
  CategoryServiceProxy
} from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { Component, OnInit, Injector, Output, EventEmitter } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent extends AppComponentBase implements OnInit {

  post: PostCreateInput = new PostCreateInput();
  categories: CategoryListDto[] = [];
  @Output() onSave = new EventEmitter<any>();
  constructor(
    injector: Injector,
    public bsModalRef: BsModalRef,
    private postService: PostServiceProxy,
    private categoryService: CategoryServiceProxy) {
    super(injector);
  }

  ngOnInit(): void {
    this.getCategories();
  }
  save() {
    this.postService.create(this.post)
      .pipe(finalize(() => {
        this.notify.success('Post Created Successfully');
      })).subscribe(() => { });
  }
  getCategories() {
    this.categoryService.getAll()
      .subscribe((result) => {
        this.categories = result.items;
      });
  }
}
