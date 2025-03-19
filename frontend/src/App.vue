<template>
  <div class="container mx-auto">
    <ContactForm />
    <SearchBar @search="handleSearch" />
    <EntityList :search-term="searchTerm" />
  </div>
</template>

<script  lang="ts">
import ContactForm from './components/ContactForm.vue';
import EntityList from './components/EntityList.vue';
import SearchBar from './components/SearchBar.vue';

export default {
  components: {
    ContactForm,
    EntityList,
    SearchBar
  },
  data() {
    return {
      searchTerm: ''
    };
  },
  methods: {
    handleSearch(term: string) {
      this.searchTerm = term;
    }
  }
};
</script>
