import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ShopListComponent } from './shop-list.component';

@NgModule(
    {
        imports: [ RouterModule.forChild([
            {path: '', redirectTo: 'list'},
            {path: 'list', component: ShopListComponent }
        ]) ],
        declarations: [ ShopListComponent ]
    }
)
export class ShopModule {}