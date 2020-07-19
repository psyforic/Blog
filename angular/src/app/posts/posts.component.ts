import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import { PostListDto, PostServiceProxy } from './../../shared/service-proxies/service-proxies';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Component, OnInit, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { CreateCategoryComponent } from '@app/categories/create-category/create-category.component';
import { CreatePostComponent } from './create-post/create-post.component';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  animations: [appModuleAnimation()],
  styleUrls: ['./posts.component.css']
})
export class PostsComponent extends AppComponentBase implements OnInit {

  posts: PostListDto[] = [];
  constructor(
    injector: Injector,
    private _postService: PostServiceProxy,
    private _modalService: BsModalService) {
    super(injector);
  }

  ngOnInit(): void {
    this.getAll();
  }
  getAll() {
    this._postService.getAll()
      .pipe(finalize(() => {

      })).subscribe((result) => {
        this.posts = result.items;
      });
  }
  create() {
    let createPost: BsModalRef;
    createPost = this._modalService.show(
      CreatePostComponent,
      {
        class: 'modal-lg',
      }
    );
    createPost.content.onSave.subscribe(() => {
      this.getAll();
    });
  }
  edit(post: any) {
    // TODO: implement method
  }
  delete(post: PostListDto) {
    // TODO: implement method
  }
}
