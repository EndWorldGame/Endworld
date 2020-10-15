import { NgModule } from "@angular/core";
import { RouterModule } from '@angular/router';
import { CreateFirstCharComponent } from './create-single-character-menu/create-first-char.component';
import { CharCreateFormComponent } from './create-single-character-menu/char-create-form.component';
import { CharCreatePreviewComponent } from './create-single-character-menu/char-create-preview.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@NgModule(
    {
        imports: [ 
            CommonModule,
            RouterModule.forChild([
                { path: '', redirectTo: 'create', pathMatch: 'full'},
                {
                    path: 'create',
                    component: CreateFirstCharComponent
                }
            ]),
            FormsModule
        ],
        declarations: [ 
            CreateFirstCharComponent,
            CharCreateFormComponent,
            CharCreatePreviewComponent 
        ]
    }
)
export class CharacterModule {}