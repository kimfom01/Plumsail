<template>
    <div class="mb-4">
        <input type="text" v-model="searchTerm" @input="onSearch" placeholder="Search..."
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline">
    </div>
</template>

<script lang="ts">
export default {
    data() {
        return {
            searchTerm: ''
        };
    },
    methods: {
        onSearch() {
            this.$emit('search', this.searchTerm);
        }
    }
};
</script>
