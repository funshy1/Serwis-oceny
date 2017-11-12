import { RankingMainComponent } from './ranking/ranking-main/ranking-main.component';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

import { ProductManagerComponent } from './admin/product-manager/product-manager.component';
import { UsersComponent } from './admin/users/users.component';
import { LoginComponent } from './auth/login/login.component';
import { MainCatalogComponent } from './catalog/main-catalog/main-catalog.component';
import { SearchBoxComponent } from './catalog/search-box/search-box.component';
import { SideMenuComponent } from './catalog/side-menu/side-menu.component';
import { AppComponent } from './core/app/app.component';
import { NavbarComponent } from './core/navbar/navbar.component';
import { AboutComponent } from './home/about/about.component';
import { HomeComponent } from './home/home/home.component';
import { NewestFeedbackComponent } from './home/newest-feedback/newest-feedback.component';
import { TopProductsComponent } from './home/top-products/top-products.component';
import { TopByCategoryComponent } from './ranking/top-by-category/top-by-category.component';
import { AddProductComponent } from './user/add-product/add-product.component';
import { AddedProductsComponent } from './user/added-products/added-products.component';
import { FavoriteProductsComponent } from './user/favorite-products/favorite-products.component';
import { MyFeedbackComponent } from './user/my-feedback/my-feedback.component';
import { MyProductsComponent } from './user/my-products/my-products.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';

@NgModule({
    declarations: [
        AppComponent,
        NavbarComponent,
        HomeComponent,
        TopProductsComponent,
        AboutComponent,
        NewestFeedbackComponent,
        SideMenuComponent,
        SearchBoxComponent,
        MainCatalogComponent,
        TopByCategoryComponent,
        MyFeedbackComponent,
        LoginComponent,
        FavoriteProductsComponent,
        MyProductsComponent,
        AddProductComponent,
        AddedProductsComponent,
        UsersComponent,
        ProductManagerComponent,
        AdminPanelComponent,
        RankingMainComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        BsDropdownModule.forRoot(),
        RouterModule.forRoot([
            { path: 'home', component: HomeComponent},
            { path: 'catalog', component: MainCatalogComponent},
            { path: 'ranking', component: RankingMainComponent},
            { path: 'login', component: LoginComponent},
            { path: 'my-feedback', component: MyFeedbackComponent},
            { path: 'add-product', component: AddedProductsComponent},
            { path: 'favorite-products', component: FavoriteProductsComponent},
            { path: 'added-products', component: AddedProductsComponent},
            { path: 'my-products', component: MyProductsComponent},
            { path: 'admin', component: AdminPanelComponent},
            { path: 'admin/product-manager', component: ProductManagerComponent},
            { path: 'admin/users', component: UsersComponent},
            { path: '*', component: HomeComponent},
            { path: '', component: HomeComponent},
        ])
    ]
})
export class AppModuleShared {
}
