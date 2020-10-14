import { NgModule } from '@angular/core';
import { FillerScreenComponent } from './filler-screen.component';
import { RouterModule } from '@angular/router';

@NgModule(
    {
        imports: [ RouterModule.forChild([
            {path: '', component: FillerScreenComponent}
        ]) ],
        declarations: [ FillerScreenComponent ]
    }
)
export class MainMenuModule {}