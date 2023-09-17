import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './core/auth.guard';
import { PageNotFoundComponent } from './shared/page-not-found/page-not-found.component';
import { UserlistComponent } from './users/userlist/userlist.component';
import { UsersComponent } from './users/users/users.component';
import { TablesComponent } from './admin/tables/tables/tables.component';

const routes: Routes = [
 {
     path: '',
     loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule),
    canActivate: [AuthGuard]
   },
  {
    path: 'login',
    loadChildren: () => import('./login/login.module').then(m => m.LoginModule),
    // path: 'login',
    //component: TablesComponent
    canActivate: [AuthGuard]

  },
  {
    path: '**',
    component: PageNotFoundComponent
  },
  {
    path: 'person',
    component: UserlistComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
