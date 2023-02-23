<script setup lang="ts">
import axios, {AxiosError} from 'axios';
import '@mdi/font/css/materialdesignicons.css';
import profileService from './services/ProfileService';
import AddBookmarkDialog from './components/AddBookmarkDialog.vue';
import AddNavigationItemDialog from './components/AddNavigationItemDialog.vue';
</script>

<template>
  <v-app id="portal">
    <v-navigation-drawer permanent theme="dark" width="250" class="mx-auto">
      <!-- Profile selection -->
      <v-select        
        label="Profile"
        :items="profiles"
        item-title="name"
        item-value="id"
        v-model="selectedProfile"
        return-object
        @update:model-value="updatePortal"
      ></v-select>

      <!-- Navigation items -->
      <v-list>
        <v-list-item-group v-model="selectedNavigationItem">
          <v-list-item
            v-for="item in navigationItems"
            :key="item.id"
            :href="item.url"
            target="contentFrame"
            active-color="primary"
          >
            <template v-slot:prepend>
              <v-icon :icon="'mdi-' + item.icon"></v-icon>
            </template>
            <v-list-item-title v-text="item.title"></v-list-item-title>
          </v-list-item>
          <v-list-item>
            <template v-slot:prepend>
              <v-icon icon="mdi-plus"></v-icon>
            </template>
            <v-list-title>Add new item</v-list-title>
            <AddNavigationItemDialog :profileId="selectedProfile?.id"
                                   @on-navigation-item-added="addNavigationItem"
            ></AddNavigationItemDialog>
          </v-list-item>
        </v-list-item-group>
      </v-list>
    </v-navigation-drawer>

    <!-- Bookmarks -->
    <v-app-bar app style="height:60px;margin-top:-4px;">
      <v-chip
        style="margin-left:1rem"
        v-for="item in bookmarks"
        :key="item.id"
        :href="item.url"
        target="_blank"
        closable
        @click:close="(e) => {e.preventDefault();deleteBookmark(item)}"
      >{{ item.title }}</v-chip>
      <v-chip style="margin-left:1rem;">
        <v-icon icon="mdi-plus"></v-icon>
        <AddBookmarkDialog :profile-id="selectedProfile?.id"
                           @on-bookmark-added="addBookmark"
        ></AddBookmarkDialog>
      </v-chip>
    </v-app-bar>

    <v-main>
      <iframe name="contentFrame" style="border:0;width:100%;height:100%"></iframe>
    </v-main>
  </v-app>
</template>

<script lang="ts">
type AppData = {
  profiles: Profile[];
  selectedProfile?: Profile;
  navigationItems: NavigationItem[];
  bookmarks: Bookmark[];
  selectedNavigationItem?: NavigationItem;
};

export default {
  data(): AppData {
    return {
      profiles: [],
      navigationItems: [],
      bookmarks: [],
    };
  },
  mounted() {
    axios
      .get<Profile[]>('/api/profile/all')
      .then(response => {
        this.profiles = response.data;
        
        if (this.profiles.length > 0) {
          const savedProfile = profileService.getSavedProfile();

          this.selectedProfile = savedProfile || this.profiles[0];
          this.updatePortal();
        }
      });
  },
  methods: {
    updatePortal() {
      if (!this.selectedProfile) return;
      
      profileService.saveProfile(this.selectedProfile);

      axios
        .get<FullProfile>(`/api/profile/${this.selectedProfile?.id}`)
        .then(response => {
          this.navigationItems = response.data.navigationItems;
          this.bookmarks = response.data.bookmarks;
        });
    },
    addBookmark(bookmark: Bookmark) {
      this.bookmarks.push(bookmark);
    },
    deleteBookmark(bookmark: Bookmark) {
      axios
        .delete(`/api/bookmark/${bookmark.id}`)
        .then(() => {
          this.bookmarks = this.bookmarks.filter(x => x.id !== bookmark.id);
        });
    },
    addNavigationItem(item: NavigationItem) {
      this.navigationItems.push(item);
    }
  },
  components: {
    AddBookmarkDialog,
    AddNavigationItemDialog
  }
};
</script>
