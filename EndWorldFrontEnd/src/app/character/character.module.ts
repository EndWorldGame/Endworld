import { NgModule } from "@angular/core";
import { RouterModule } from '@angular/router';
import { CreateFirstCharComponent } from './character-create/create-first-char.component';
import { CharCreateFormComponent } from './character-create/char-create-form.component';
import { CharCreatePreviewComponent } from './character-create/char-create-preview.component';
import { CharClassService } from '../common/services/char-class.service';
import { CharRaceService } from '../common/services/char-race.service';
import { PartyService } from '../common/services/party.service';
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