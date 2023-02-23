<script setup lang="ts">
import axios from 'axios';
</script>

<template>
    <v-dialog activator="parent" width="512" v-model="showDialog">
        <v-card>
            <v-card-title>
                <span class="text-h5">Add a new bookmark</span>
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
                </v-container>
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue-darken-1" variant="text" @click="cancel">Cancel</v-btn>
                <v-btn color="blue-darken-1" variant="text" @click="addBookmark">Add</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script lang="ts">
type AddBookmarkDialogData = {
    profileId: number;
    title: string;
    url: string;
    showDialog: boolean;
};

export default {
    props: ['profileId'],
    data(): AddBookmarkDialogData {
        return {
            profileId: this.profileId,
            title: '',
            url: 'https://',
            showDialog: false,
        };
    },
    methods: {
        addBookmark() {
            const model: AddBookmarkModel = {
                profileId: this.profileId,
                title: this.title,
                url: this.url,
            };
            
            axios
                .post<Bookmark>('/api/bookmark', model)
                .then(response => {
                    this.showDialog = false;
                    this.$emit('onBookmarkAdded', response.data);
                    this.title = '';
                    this.url = 'https://';
                });
        },
        cancel() {
            this.title = '';
            this.url = 'https://';
            this.showDialog = false;
        }
    }
};
</script>