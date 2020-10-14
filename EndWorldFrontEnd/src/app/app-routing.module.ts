import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateFirstCharComponent } from './character/character-create/create-first-char.component';
import { CharGuard } from './common/guards/char.guard';


const routes: Routes = [
  { 
    path: 'main', 
    loadChildren: () => import('./main-menu/main-menu.module').then(m => m.MainMenuModule),
    canActivate: [ CharGuard ] 
  },
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: 'battle',
    loadChildren: () => import('./battle/battle.module').then(m => m.BattleModule),
    canActivate: [ CharGuard ] 
  },
  {
    path: 'character',
    loadChildren: () => import('./character/character.module').then(m => m.CharacterModule)
  },
  {
    path: 'shop',
    loadChildren: () => import('./shop/shop.module').then(m => m.ShopModule),
    canActivate: [ CharGuard ] 
  },
  { path: '', redirectTo: 'main', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
