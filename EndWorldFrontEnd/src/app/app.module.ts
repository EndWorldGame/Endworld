import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CharCreateFormComponent } from './character/character-create/char-create-form.component';
import { CharCreatePreviewComponent } from './character/character-create/char-create-preview.component';
import { CharClassService } from './common/services/char-class.service';
import { CharRaceService } from './common/services/char-race.service';
import { PartyService } from './common/services/party.service';
import { CreateFirstCharComponent } from './character/character-create/create-first-char.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    CharClassService,
    CharRaceService,
    PartyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
