<script setup lang="ts">
import axios from 'axios';
</script>

<template>
    <v-dialog activator="parent" width="512" v-model="showDialog">
        <v-card>
            <v-card-title>
                <span class="text-h5">Add a new navigation item</span>
            </v-card-title>
            <v-card-text>
                <v-container>
                    <v-row>
                        <v-col cols="12">
                            <v-text-field label="Title" 
                                          required
                                          v-model="title"></v-text-field>
                        </v-col>
                    </v-row>
                    <v-row>
                        <v-col cols="12">
                            <v-text-field label="URL" 
                                          required
                                          v-model="url"></v-text-field>
                        </v-col>
                    </v-row>
                    <v-row>
                        <v-col cols="12">
                            <v-text-field label="Icon (https://vuetifyjs.com/en/components/icons/)" 
                                          required
                                          v-model="icon"></v-text-field>
                        </v-col>
                    </v-row>
                </v-container>
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue-darken-1" variant="text" @click="cancel">Cancel</v-btn>
                <v-btn color="blue-darken-1" variant="text" @click="addNavigationItem">Add</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script lang="ts">
type AddNavigationItemDialogData = {
    profileId: number;
    title: string;
    url: string;
    icon: string;
    showDialog: boolean;
};

export default {
    props: ['profileId'],
    data(): AddNavigationItemDialogData {
        return {
            profileId: this.profileId,
            title: '',
            url: 'https://',
            icon: 'mdi-',
            showDialog: false,
        };
    },
    methods: {
        addNavigationItem() {
            const model: AddNavigationItemModel = {
                profileId: this.profileId,
                title: this.title,
                url: this.url,
                icon: this.icon
            };
            
            axios
                .post<Bookmark>('/api/navigation-item', model)
                .then(response => {
                    this.showDialog = false;
                    this.$emit('onNavigationItemAdded', response.data);
                    this.title = '';
                    this.url = 'https://';
                    this.icon = 'mdi-';
                });
        },
        cancel() {
            this.title = '';
            this.url = 'https://';
            this.icon = 'mdi-';
            this.showDialog = false;
        }
    }
};
</script>