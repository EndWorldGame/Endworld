import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BattleListOptionComponent } from './battle-list-option/battle-list-option.component';
import { BattleListComponent } from './battle-list/battle-list.component';

@NgModule(
    {
        imports: [ 
            CommonModule,
            RouterModule.forChild([
            {path: '', redirectTo: 'list'},
            {path: 'list', component: BattleListComponent}
        ]) ],
        declarations: [ BattleListComponent, BattleListOptionComponent ]
    }
)
export class BattleModule {}